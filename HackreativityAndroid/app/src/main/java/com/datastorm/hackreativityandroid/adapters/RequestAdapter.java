package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.adapters.holders.RequestHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;


public class RequestAdapter extends BaseListAdapter<Request, RequestHolder> {

	@Override
	public long getItemId(int position) {
		return getItem(position).getId();
	}

	@Override
	protected RequestHolder getHolder(ViewGroup parent, int viewType) {
		return null;
	}
}
