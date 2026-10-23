namespace System.Threading.Tasks
{
	public class Parallel
	{
		public delegate void ForLoopBody(int i);

		private Parallel Instance;

		private AutoResetEvent[] jobAvailable;

		private ManualResetEvent[] threadIdle;

		private Thread[] threads;

		private static object sync = new object();

		private int currentIndex;

		private int stopIndex;

		private int step = 1;

		private ForLoopBody loopBody;

		public static int threadsCount = 2;

		public static int iterationStepLength = 10;

		private void Initialize()
		{
			threadsCount = Environment.ProcessorCount;
			if (threadsCount > 1)
			{
				jobAvailable = new AutoResetEvent[threadsCount];
				threadIdle = new ManualResetEvent[threadsCount];
				threads = new Thread[threadsCount];
				for (int i = 0; i < threadsCount; i++)
				{
					jobAvailable[i] = new AutoResetEvent(false);
					threadIdle[i] = new ManualResetEvent(true);
					threads[i] = new Thread(WorkerThread);
					threads[i].IsBackground = false;
					threads[i].Start(i);
				}
			}
		}

		public void Close()
		{
			loopBody = null;
			for (int i = 0; i < threadsCount; i++)
			{
				jobAvailable[i].Set();
			}
		}

		public static void For(int start, int stop, ForLoopBody loopBody)
		{
			For(start, stop, 1, loopBody);
		}

		public static void For(int start, int stop, int stepLength, ForLoopBody loopBody)
		{
			For(start, stop, stepLength, loopBody, true);
		}

		public static void For(int start, int stop, int stepLength, ForLoopBody loopBody, bool close)
		{
			Parallel parallel = new Parallel();
			parallel.Initialize();
			parallel.ForLoop(start, stop, stepLength, loopBody, close);
		}

		public void ForLoop(int start, int stop, int stepLength, ForLoopBody loopBody, bool close)
		{
			lock (sync)
			{
				stepLength = ((stepLength < 1) ? 1 : stepLength);
				currentIndex = start;
				stopIndex = stop;
				this.loopBody = loopBody;
				step = stepLength;
				if (threadsCount <= 1)
				{
					for (int i = start; i < stop; i += stepLength)
					{
						loopBody(i);
					}
					return;
				}
				for (int j = 0; j < threadsCount; j++)
				{
					threadIdle[j].Reset();
					jobAvailable[j].Set();
				}
				for (int k = 0; k < threadsCount; k++)
				{
					threadIdle[k].WaitOne();
				}
				if (close)
				{
					Close();
				}
			}
		}

		private void WorkerThread(object index)
		{
			int num = (int)index;
			int num2 = 0;
			while (true)
			{
				jobAvailable[num].WaitOne();
				if (loopBody == null)
				{
					break;
				}
				bool flag;
				do
				{
					num2 = Interlocked.Add(ref currentIndex, iterationStepLength * step);
					int num3 = num2 - iterationStepLength * step;
					flag = false;
					if (num2 >= stopIndex)
					{
						flag = true;
						num2 = stopIndex;
					}
					for (int i = num3; i < num2; i += step)
					{
						loopBody(i);
					}
				}
				while (!flag);
				threadIdle[num].Set();
			}
		}
	}
}
