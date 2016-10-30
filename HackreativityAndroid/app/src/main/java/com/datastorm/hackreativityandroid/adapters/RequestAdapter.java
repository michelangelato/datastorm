package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.holders.RequestHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;


public class RequestAdapter extends BaseListAdapter<Request, RequestHolder> {

	@Override
	public long getItemIdSafe(int position) {
		return getItem(position).getId();
	}

	@Override
	protected RequestHolder getHolder(ViewGroup parent, int viewType) {
		return new RequestHolder(
				inflater(parent.getContext()).inflate(R.layout.item_request, parent, false),
				false);
	}
}
