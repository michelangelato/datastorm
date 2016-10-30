package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapView;
import com.google.android.gms.maps.MapsInitializer;
import com.google.android.gms.maps.OnMapReadyCallback;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;

import static com.datastorm.hackreativityandroid.utils.MapDrawer.setupMap;


public class AlertMapHolder extends AlertTextOnlyHolder implements OnMapReadyCallback {

	@BindView(R.id.alert_map)
	MapView map;
	private List<MapObject> mapObjects;

	public AlertMapHolder(View itemView) {
		super(itemView);
		ButterKnife.bind(itemView);
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
		setupMap(map.getContext(), googleMap, mapObjects);
	}
}
