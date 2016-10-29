package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;
import android.widget.TextView;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;

import butterknife.BindView;
import butterknife.ButterKnife;


public class AlertTextOnlyHolder extends AlertBaseHolder {

	@BindView(R.id.alert_title)
	TextView title;
	@BindView(R.id.alert_description)
	TextView description;

	public AlertTextOnlyHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
		ButterKnife.bind(itemView);
	}

	@Override
	public void bindItem(Alert item, int position) {
		title.setText(item.getTitle());
		description.setText(item.getDescription());
	}
}
