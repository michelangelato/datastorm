package com.datastorm.hackreativityandroid.interfaces;

import android.view.View;

import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

public interface OnTopicClickedListener {

	void onTopicClicked(View v, Topic topic);
}
