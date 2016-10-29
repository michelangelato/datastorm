package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public class AlertSimpleHolder extends AlertBaseHolder {

	public AlertSimpleHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}

	@Override
	public void bindItem(Alert item, int position) {
		//TODO show hetero infos
	}
}
