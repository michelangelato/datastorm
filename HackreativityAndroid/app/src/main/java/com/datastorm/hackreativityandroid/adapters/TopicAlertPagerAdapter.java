package com.datastorm.hackreativityandroid.adapters;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import com.datastorm.hackreativityandroid.fragments.AddTopicFragment;
import com.datastorm.hackreativityandroid.fragments.AlertListFragment;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

public class TopicAlertPagerAdapter extends FragmentPagerAdapter {

	private List<Topic> topics;

	public TopicAlertPagerAdapter(FragmentManager fragmentManager) {
		super(fragmentManager);
	}

	public void setTopics(List<Topic> topics) {
		this.topics = topics;
		notifyDataSetChanged();
	}

	@Override
	public int getCount() {
		return (topics != null ? topics.size() : 0) + 1;
	}

	@Override
	public CharSequence getPageTitle(int position) {
		int lastPosition = getCount() - 1;
		if (position == lastPosition) return "Aggiungi una colonna";
		return getTopic(position).getTopic();
	}

	@Override
	public Fragment getItem(int position) {
		int lastPosition = getCount() - 1;
		if (position == lastPosition) return AddTopicFragment.newInstance();
		return AlertListFragment.newInstance(getTopic(position).getTopic());
	}

	private Topic getTopic(int position) {
		return topics.get(position);
	}
}
