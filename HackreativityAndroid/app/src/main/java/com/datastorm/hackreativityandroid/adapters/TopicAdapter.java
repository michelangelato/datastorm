package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.adapters.holders.TopicHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;


public class TopicAdapter extends BaseListAdapter<Topic, TopicHolder> {

	@Override
	public long getItemIdSafe(int position) {
		return getItem(position).getTopic()
		                        .hashCode();
	}

	@Override
	protected TopicHolder getHolder(ViewGroup parent, int viewType) {
		return null;
	}
}
