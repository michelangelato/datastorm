package com.datastorm.hackreativityandroid.interfaces;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

public interface OnAlertListInteractionListener {

	void onAlertClicked(View view, Alert alert);
	void onMapShortcutClicked(View v);
	void onRequestShortcutClicked(View v);
	void onReportShortcutClicked(View v);
}
