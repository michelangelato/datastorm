package com.datastorm.hackreativityandroid.adapters.holders;

import android.view.View;

import com.dadino.quickstart.core.adapters.holders.BaseHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import butterknife.ButterKnife;

public class TopicHolder extends BaseHolder<Topic> {

	public TopicHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
		ButterKnife.bind(itemView);

	}

	@Override
	public void bindItem(Topic item, int position) {
		//TODO
	}
}
