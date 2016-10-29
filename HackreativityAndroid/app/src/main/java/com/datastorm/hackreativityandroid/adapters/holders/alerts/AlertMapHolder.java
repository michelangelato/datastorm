package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.google.android.gms.maps.MapView;

import butterknife.BindView;


public class AlertMapHolder extends AlertTextOnlyHolder {

	@BindView(R.id.alert_map)
	MapView map;

	public AlertMapHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}

	@Override
	public void bindItem(Alert item, int position) {
		super.bindItem(item, position);
		//TODO load map
	}
}
