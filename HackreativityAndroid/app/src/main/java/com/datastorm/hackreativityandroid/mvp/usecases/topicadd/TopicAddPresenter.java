package com.datastorm.hackreativityandroid.mvp.usecases.topicadd;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;

import rx.Observable;

public class TopicAddPresenter extends Presenter<Boolean, TopicAddMVP.Model> implements
		TopicAddMVP.Presenter {


	public TopicAddPresenter(Context context) {
		super(new TopicAddModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<Boolean> loadItemsInternal(boolean userInitiatedLoad) {
		throw new RuntimeException("Method not implemented");
	}

	@Override
	protected String tag() {
		return "TopicAdd";
	}

	@Override
	public void onAddClicked(String topic) {
		model().add(topic);
	}
}
