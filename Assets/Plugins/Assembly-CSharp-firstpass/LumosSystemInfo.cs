using System.Collections.Generic;
using UnityEngine;

public class LumosSystemInfo
{
	public static void Record()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Lumos.LogWarning("Apple's ToS prevents device data from being sent on iOS");
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("player_id", Lumos.playerId);
		dictionary.Add("operating_system", SystemInfo.operatingSystem);
		dictionary.Add("processor_type", SystemInfo.processorType);
		dictionary.Add("processor_count", SystemInfo.processorCount);
		dictionary.Add("system_memory_size", SystemInfo.systemMemorySize);
		dictionary.Add("graphics_memory_size", SystemInfo.graphicsMemorySize);
		dictionary.Add("graphics_device_name", SystemInfo.graphicsDeviceName);
		dictionary.Add("graphics_device_vendor", SystemInfo.graphicsDeviceVendor);
		dictionary.Add("graphics_device_id", SystemInfo.graphicsDeviceID);
		dictionary.Add("graphics_device_vendor_id", SystemInfo.graphicsDeviceVendorID);
		dictionary.Add("graphics_device_version", SystemInfo.graphicsDeviceVersion);
		dictionary.Add("graphics_shader_level", SystemInfo.graphicsShaderLevel);
		dictionary.Add("graphics_pixel_fillrate", SystemInfo.graphicsPixelFillrate);
		dictionary.Add("supports_shadows", SystemInfo.supportsShadows);
		dictionary.Add("supports_render_textures", SystemInfo.supportsRenderTextures);
		dictionary.Add("supports_image_effects", SystemInfo.supportsImageEffects);
		Dictionary<string, object> parameters = dictionary;
		LumosWWW.Send("system-info.record", parameters);
	}
}
