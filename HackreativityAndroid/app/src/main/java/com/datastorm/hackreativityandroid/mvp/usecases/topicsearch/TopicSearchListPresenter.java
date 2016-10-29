package com.datastorm.hackreativityandroid.mvp.usecases.topicsearch;

import android.content.Context;

import com.dadino.quickstart.core.mvp.components.presenter.Presenter;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;

import java.util.List;

import rx.Observable;

public class TopicSearchListPresenter extends Presenter<List<Topic>, TopicSearchListMVP.Model>
		implements
		TopicSearchListMVP.Presenter {


	public TopicSearchListPresenter(Context context) {
		super(new TopicSearchListModel(context.getApplicationContext()));
		setPublishLoadFinishedOnNext(true);
	}

	@Override
	protected Observable<List<Topic>> loadItemsInternal(boolean userInitiatedLoad) {
		throw new RuntimeException("Method not implemented");
	}

	@Override
	protected String tag() {
		return "TopicSearchList";
	}

	@Override
	public void onFilterChanged(String filter) {
		model().search(filter);
	}
}
