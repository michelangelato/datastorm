package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Spinner;

import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnRequestNewInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class RequestNewFragment extends DrawerToggleFragment {

	public static final String TAG = "ReportFragment";

	@BindView(R.id.toolbar)
	Toolbar  toolbar;
	@BindView(R.id.new_request_address)
	EditText address;
	@BindView(R.id.new_request_type)
	Spinner  type;
	@BindView(R.id.new_request_condition_door)
	CheckBox door;
	@BindView(R.id.new_request_condition_stairs)
	CheckBox stairs;
	@BindView(R.id.new_request_send)
	Button   send;

	private Unbinder unbinder;

	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iRequestNewView = new MvpView<>(this::onError, this);


	private OnRequestNewInteractionListener mListener;

	public RequestNewFragment() {
		// Required empty public constructor
	}


	public static RequestNewFragment newInstance() {
		RequestNewFragment fragment = new RequestNewFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}

	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnRequestNewInteractionListener) {
			mListener = (OnRequestNewInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnRequestNewInteractionListener");
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
		return R.string.fragment_title_request_new;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		initPresenters();
	}

	private void initPresenters() {
		alertListPresenterManager = new PresenterManager<>(this, new AlertListMVP.Factory(),
				IPresenter::load).bindTo(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_request_new, container, false);
		unbinder = ButterKnife.bind(this, view);
		return view;
	}

	@Override
	public void onResume() {
		super.onResume();
		if (alertListPresenter() != null) alertListPresenter().addView(iRequestNewView);
	}

	@Override
	public void onPause() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iRequestNewView);

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
