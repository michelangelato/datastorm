package com.datastorm.hackreativityandroid.interfaces;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

public interface OnAlertListClickListener {

	void onMapShortcutClicked(View v);
	void onRequestShortcutClicked(View v);
	void onReportShortcutClicked(View v);
	void onAlertClicked(View v, Alert alert);
}
