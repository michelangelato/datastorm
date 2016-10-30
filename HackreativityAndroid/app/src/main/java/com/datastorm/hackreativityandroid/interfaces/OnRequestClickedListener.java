package com.datastorm.hackreativityandroid.interfaces;


import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Request;

public interface OnRequestClickedListener {

	void onRequestClicked(View view, Request alert);
}
