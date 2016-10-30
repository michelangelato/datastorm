package com.datastorm.hackreativityandroid.interfaces;


import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

public interface OnAlertClickedListener {

	void onAlertClicked(View view, Alert alert);
}
