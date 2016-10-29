package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.dadino.quickstart.core.adapters.holders.BaseHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;

public class RequestHolder extends BaseHolder<Request> {

	public RequestHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}

	@Override
	public void bindItem(Request item, int position) {
		//TODO
	}
}
