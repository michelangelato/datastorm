package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.dadino.quickstart.core.adapters.holders.BaseHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public abstract class AlertBaseHolder extends BaseHolder<Alert> {

	public AlertBaseHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}
}
