package com.datastorm.hackreativityandroid.fragments;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.View;

import com.dadino.quickstart.core.interfaces.ISub;
import com.datastorm.hackreativityandroid.HackApp;

import rx.Subscription;
import rx.subscriptions.CompositeSubscription;


public abstract class BaseFragment extends Fragment implements ISub {

	private CompositeSubscription mSubscriptions;
	private boolean mShouldWatchForLeaks = true;


	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		mSubscriptions = new CompositeSubscription();
	}

	@Override
	public void onViewCreated(View view, Bundle savedInstanceState) {
		super.onViewCreated(view, savedInstanceState);
	}


	@Override
	public void onDestroy() {
		super.onDestroy();
		mSubscriptions.unsubscribe();
		if (mShouldWatchForLeaks) {
			HackApp.getRefWatcher(getActivity())
			       .watch(this);
		}
	}

	public void shouldWatchForLeaks(boolean watchForLeaks) {
		this.mShouldWatchForLeaks = watchForLeaks;
	}

	public void addSubscription(Subscription subscription) {
		mSubscriptions.add(subscription);
	}

	@Override
	public void onNewSubscription(Subscription subscription) {
		addSubscription(subscription);
	}
}

