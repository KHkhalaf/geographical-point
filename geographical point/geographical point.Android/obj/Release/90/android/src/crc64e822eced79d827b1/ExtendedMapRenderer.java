package crc64e822eced79d827b1;


public class ExtendedMapRenderer
	extends crc648aad9efe354a1d8f.MapRenderer
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.OnMapReadyCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMapReady:(Lcom/google/android/gms/maps/GoogleMap;)V:GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler:Android.Gms.Maps.IOnMapReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("geographical_point.Droid.ExtendedMapRenderer, geographical point.Android", ExtendedMapRenderer.class, __md_methods);
	}


	public ExtendedMapRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ExtendedMapRenderer.class)
			mono.android.TypeManager.Activate ("geographical_point.Droid.ExtendedMapRenderer, geographical point.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ExtendedMapRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ExtendedMapRenderer.class)
			mono.android.TypeManager.Activate ("geographical_point.Droid.ExtendedMapRenderer, geographical point.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ExtendedMapRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ExtendedMapRenderer.class)
			mono.android.TypeManager.Activate ("geographical_point.Droid.ExtendedMapRenderer, geographical point.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onMapReady (com.google.android.gms.maps.GoogleMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.google.android.gms.maps.GoogleMap p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
