package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnRequestListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;
import com.datastorm.hackreativityandroid.widgets.HideableFab;
import com.datastorm.hackreativityandroid.widgets.PresentedRequestListView;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class RequestListFragment extends DrawerToggleFragment {

	public static final  String TAG       = "AlertListFragment";
	private static final String ARG_TOPIC = "topic";

	@BindView(R.id.toolbar)
	Toolbar                  toolbar;
	@BindView(R.id.request_list)
	PresentedRequestListView alertList;
	@BindView(R.id.request_new_fab)
	HideableFab              fab;

	private String   mTopic;
	private Unbinder unbinder;

	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iAlertListView = new MvpView<>(this::onError, this);


	private OnRequestListInteractionListener mListener;

	public RequestListFragment() {
		// Required empty public constructor
	}

	public static RequestListFragment newInstance(String topic) {
		RequestListFragment fragment = new RequestListFragment();
		Bundle args = new Bundle();
		args.putString(ARG_TOPIC, topic);
		fragment.setArguments(args);
		return fragment;
	}

	public static RequestListFragment newInstance() {
		RequestListFragment fragment = new RequestListFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}

	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnRequestListInteractionListener) {
			mListener = (OnRequestListInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnRequestListInteractionListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	@Override
	Toolbar toolbar() {
		return toolbar;
	}

	@Override
	protected int title() {
		return R.string.fragment_title_requests_list;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		if (getArguments() != null) {
			mTopic = getArguments().getString(ARG_TOPIC);
		}

		initPresenters();
	}

	private void initPresenters() {
		alertListPresenterManager = new PresenterManager<>(this, new AlertListMVP.Factory(),
				IPresenter::load).bindTo(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_request_list, container, false);
		unbinder = ButterKnife.bind(this, view);
		fab.setOnClickListener(v -> {
			if (mListener != null) mListener.onNewRequestClicked();
		});
		return view;
	}

	@Override
	public void onResume() {
		super.onResume();
		if (alertListPresenter() != null) alertListPresenter().addView(iAlertListView);
		if (alertList != null) alertList.setPresenter(alertListPresenter());
	}

	@Override
	public void onPause() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iAlertListView);
		if (alertList != null) alertList.setPresenter(null);

		super.onPause();
	}

	@Override
	public void onDestroyView() {
		unbinder.unbind();
		super.onDestroyView();
	}

	private void onError(Throwable error) {
		//TODO
	}

	private AlertListMVP.Presenter alertListPresenter() {
		return alertListPresenterManager != null ? alertListPresenterManager.get() : null;
	}
}
