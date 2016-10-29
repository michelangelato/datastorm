package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public class AlertReportHolder extends AlertBaseHolder {

	public AlertReportHolder(View itemView) {
		super(itemView, true);
	}

	@Override
	public void bindItem(Alert item, int position) {
		//TODO Segnalazioni (Clicca per segnalare)
	}
}
