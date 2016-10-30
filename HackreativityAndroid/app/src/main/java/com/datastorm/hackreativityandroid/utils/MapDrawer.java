package com.datastorm.hackreativityandroid.utils;

import android.content.Context;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.entitites.MapPoint;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.LatLngBounds;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.PolygonOptions;
import com.google.android.gms.maps.model.PolylineOptions;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by davidcorsalini on 30/10/16.
 */

public class MapDrawer {

	public static void drawPoint(GoogleMap map, MapObject mapObject) {
		for (MapPoint mapPoint : mapObject.getPoints()) {
			map.addMarker(new MarkerOptions().position(
					new LatLng(mapPoint.getLat(), mapPoint.getLon()))
			                                 .title(mapObject.getTitle())
			                                 .snippet(mapObject.getDescription()));
		}
	}

	public static void drawPolyline(GoogleMap map, MapObject mapObject) {
		List<LatLng> points = new ArrayList<>();
		for (MapPoint mapPoint : mapObject.getPoints()) {
			points.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
		}
		map.addPolyline(new PolylineOptions().addAll(points));
	}

	public static void drawPolygon(GoogleMap map, MapObject mapObject) {
		List<LatLng> points = new ArrayList<>();
		for (MapPoint mapPoint : mapObject.getPoints()) {
			points.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
		}
		map.addPolygon(new PolygonOptions().addAll(points));
	}

	public static void setupMap(Context context, GoogleMap googleMap, List<MapObject> mapObjects) {
		List<LatLng> locs = new ArrayList<>();
		for (MapObject mapObject : mapObjects) {
			if (mapObject.getType() == Constants.TYPE_POINT) drawPoint(googleMap, mapObject);
			if (mapObject.getType() == Constants.TYPE_POLYLINE) drawPolyline(googleMap, mapObject);
			if (mapObject.getType() == Constants.TYPE_POLYGON) drawPolygon(googleMap, mapObject);

			for (MapPoint mapPoint : mapObject.getPoints()) {
				locs.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
			}
		}

		final LatLngBounds.Builder builder = LatLngBounds.builder();
		for (LatLng loc : locs) {
			builder.include(loc);
		}
		final int padding = context.getResources()
		                           .getDimensionPixelSize(R.dimen.dimen_4dp);
		googleMap.moveCamera(CameraUpdateFactory.newLatLngBounds(builder.build(), padding));
	}
}
