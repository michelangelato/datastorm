package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.entitites.MapPoint;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapView;
import com.google.android.gms.maps.MapsInitializer;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.LatLngBounds;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.PolygonOptions;
import com.google.android.gms.maps.model.PolylineOptions;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;


public class AlertMapHolder extends AlertTextOnlyHolder implements OnMapReadyCallback {

	@BindView(R.id.alert_map)
	MapView map;
	private List<MapObject> mapObjects;

	public AlertMapHolder(View itemView) {
		super(itemView);
	}

	@Override
	public void bindItem(Alert item, int position) {
		super.bindItem(item, position);
		this.mapObjects = item.getMaps();
		map.onCreate(null);
		map.onResume();
		map.getMapAsync(this);
	}

	@Override
	public void onMapReady(GoogleMap googleMap) {
		MapsInitializer.initialize(map.getContext()
		                              .getApplicationContext());

		List<LatLng> locs = new ArrayList<>();
		for (MapObject mapObject : mapObjects) {
			if (mapObject.getType() == MapObject.TYPE_POINT) drawPoint(googleMap, mapObject);
			if (mapObject.getType() == MapObject.TYPE_POLYLINE) drawPolyline(googleMap, mapObject);
			if (mapObject.getType() == MapObject.TYPE_POLYGON) drawPolygon(googleMap, mapObject);

			for (MapPoint mapPoint : mapObject.getPoints()) {
				locs.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
			}
		}

		final LatLngBounds.Builder builder = LatLngBounds.builder();
		for (LatLng loc : locs) {
			builder.include(loc);
		}
		final int padding = map.getResources()
		                       .getDimensionPixelSize(R.dimen.dimen_4dp);
		googleMap.moveCamera(CameraUpdateFactory.newLatLngBounds(builder.build(), padding));
	}

	private void drawPoint(GoogleMap map, MapObject mapObject) {
		for (MapPoint mapPoint : mapObject.getPoints()) {
			map.addMarker(new MarkerOptions().position(
					new LatLng(mapPoint.getLat(), mapPoint.getLon()))
			                                 .title(mapObject.getTitle())
			                                 .snippet(mapObject.getDescription()));
		}
	}

	private void drawPolyline(GoogleMap map, MapObject mapObject) {
		List<LatLng> points = new ArrayList<>();
		for (MapPoint mapPoint : mapObject.getPoints()) {
			points.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
		}
		map.addPolyline(new PolylineOptions().addAll(points));
	}

	private void drawPolygon(GoogleMap map, MapObject mapObject) {
		List<LatLng> points = new ArrayList<>();
		for (MapPoint mapPoint : mapObject.getPoints()) {
			points.add(new LatLng(mapPoint.getLat(), mapPoint.getLon()));
		}
		map.addPolygon(new PolygonOptions().addAll(points));
	}
}
