package com.datastorm.hackreativityandroid.widgets;

import android.content.Context;
import android.support.v7.widget.LinearLayoutManager;
import android.util.AttributeSet;

import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.RequestAdapter;
import com.datastorm.hackreativityandroid.interfaces.OnRequestClickedListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.usecases.requestlist.RequestListMVP;

import java.util.List;


public class PresentedRequestListView extends RecyclerLayout<RequestAdapter, LinearLayoutManager> {

	private RequestListMVP.Presenter mPresenter;
	private MvpView<List<Request>> iView = new MvpView<>(this::onItemNext, this::onItemLoad);
	private OnRequestClickedListener listener;

	public PresentedRequestListView(Context context) {
		super(context);
	}

	public PresentedRequestListView(Context context, AttributeSet attrs) {
		super(context, attrs);
	}


	@Override
	protected void initialize() {
		setEmptyText(R.string.empty_requests);
		setLayoutManager(new LinearLayoutManager(getContext()));
		final RequestAdapter adapter = new RequestAdapter();
		adapter.setClickListener((v, request) -> {
			if (listener != null) listener.onRequestClicked(v, request);
		});
		setAdapter(adapter);
		setEnabled(false);
	}

	public void onItemNext(List<Request> item) {
		mAdapter.setItems(item);
	}


	public void onItemLoad(boolean loading) {
		setListLoading(loading);
	}

	public void setOnRequestClickedListener(OnRequestClickedListener listener) {
		this.listener = listener;
	}

	public void setPresenter(RequestListMVP.Presenter presenter) {
		if (mPresenter != null) mPresenter.removeView(iView);
		mPresenter = presenter;
		if (mPresenter != null) mPresenter.addView(iView);
	}
}
