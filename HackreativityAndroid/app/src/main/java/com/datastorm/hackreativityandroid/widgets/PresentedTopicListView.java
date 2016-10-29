package com.datastorm.hackreativityandroid.widgets;

import android.content.Context;
import android.support.v7.widget.LinearLayoutManager;
import android.util.AttributeSet;

import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.TopicAdapter;
import com.datastorm.hackreativityandroid.interfaces.OnTopicClickedListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;
import com.datastorm.hackreativityandroid.mvp.usecases.topicsearch.TopicSearchListMVP;

import java.util.List;


public class PresentedTopicListView extends RecyclerLayout<TopicAdapter, LinearLayoutManager> {

	private TopicSearchListMVP.Presenter mPresenter;
	private MvpView<List<Topic>> iView = new MvpView<>(this::onItemNext, this::onItemLoad);
	private OnTopicClickedListener listener;

	public PresentedTopicListView(Context context) {
		super(context);
	}

	public PresentedTopicListView(Context context, AttributeSet attrs) {
		super(context, attrs);
	}


	@Override
	protected void initialize() {
		setEmptyText(R.string.empty_alerts);
		setLayoutManager(new LinearLayoutManager(getContext()));
		final TopicAdapter adapter = new TopicAdapter();
		adapter.setClickListener((v, alert) -> {
			if (listener != null) listener.onTopicClicked(v, alert);
		});
		setAdapter(adapter);
		setEnabled(false);
	}

	public void onItemNext(List<Topic> item) {
		mAdapter.setItems(item);
	}


	public void onItemLoad(boolean loading) {
		setListLoading(loading);
	}

	public void setOnTopicClickedListener(OnTopicClickedListener listener) {
		this.listener = listener;
	}

	public void setPresenter(TopicSearchListMVP.Presenter presenter) {
		if (mPresenter != null) mPresenter.removeView(iView);
		mPresenter = presenter;
		if (mPresenter != null) mPresenter.addView(iView);
	}
}
