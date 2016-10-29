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
import com.datastorm.hackreativityandroid.interfaces.OnAlertClickedListener;
import com.datastorm.hackreativityandroid.interfaces.OnAlertListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;
import com.datastorm.hackreativityandroid.widgets.PresentedAlertListView;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class AlertListFragment extends DrawerToggleFragment implements OnAlertClickedListener {

	public static final  String TAG       = "AlertListFragment";
	private static final String ARG_TOPIC = "topic";
	@BindView(R.id.alert_list)
	PresentedAlertListView alertList;
	@BindView(R.id.toolbar)
	Toolbar                toolbar;
	private String   mTopic;
	private Unbinder unbinder;

	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iAlertListView = new MvpView<>(this::onError, this);


	private OnAlertListInteractionListener mListener;

	public AlertListFragment() {
		// Required empty public constructor
	}

	public static AlertListFragment newInstance(String topic) {
		AlertListFragment fragment = new AlertListFragment();
		Bundle args = new Bundle();
		args.putString(ARG_TOPIC, topic);
		fragment.setArguments(args);
		return fragment;
	}

	public static AlertListFragment newInstance() {
		AlertListFragment fragment = new AlertListFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}


	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnAlertListInteractionListener) {
			mListener = (OnAlertListInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnFragmentInteractionListener");
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
		View view = inflater.inflate(R.layout.fragment_alert_list, container, false);
		unbinder = ButterKnife.bind(this, view);
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

	@Override
	public void onAlertClicked(View view, Alert alert) {
		if (mListener != null) mListener.onAlertClicked(view, alert);
	}


	private void onError(Throwable error) {
		//TODO
	}

	private AlertListMVP.Presenter alertListPresenter() {
		return alertListPresenterManager != null ? alertListPresenterManager.get() : null;
	}
}
