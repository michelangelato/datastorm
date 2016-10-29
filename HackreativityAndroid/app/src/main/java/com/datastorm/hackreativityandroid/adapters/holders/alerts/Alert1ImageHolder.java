package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;
import android.widget.ImageView;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import butterknife.BindView;


public class Alert1ImageHolder extends AlertTextOnlyHolder {

	@BindView(R.id.alert_image_1)
	ImageView image;

	public Alert1ImageHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}

	@Override
	public void bindItem(Alert item, int position) {
		super.bindItem(item, position);
		//TODO load image in imageView
	}
}
