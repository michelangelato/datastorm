package com.datastorm.hackreativityandroid.utils;

import android.content.Context;

import com.datastorm.hackreativityandroid.R;

/**
 * Created by davidcorsalini on 30/10/16.
 */
public class Constants {

	public static final int TYPE_POINT    = 1;
	public static final int TYPE_POLYLINE = 2;
	public static final int TYPE_POLYGON  = 3;

	public static String typeString(Context context, int type) {
		switch (type) {
			case 0:
				return context.getString(R.string.request_type_check);
			case 1:
				return context.getString(R.string.request_type_rescue);
			default:
				return "";
		}
	}
}
