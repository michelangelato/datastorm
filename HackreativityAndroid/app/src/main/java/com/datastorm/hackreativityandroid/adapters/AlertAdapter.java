package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.adapters.holders.AlertBaseHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;


public class AlertAdapter extends BaseListAdapter<Alert, AlertBaseHolder> {

	@Override
	public long getItemId(int position) {
		return getItem(position).getId();
	}

	@Override
	protected AlertBaseHolder getHolder(ViewGroup parent, int viewType) {
		return null;
	}
}
