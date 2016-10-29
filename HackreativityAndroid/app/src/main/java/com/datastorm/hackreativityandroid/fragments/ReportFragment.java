package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnAlertClickedListener;
import com.datastorm.hackreativityandroid.interfaces.OnAlertListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class ReportFragment extends DrawerToggleFragment implements OnAlertClickedListener {

	public static final String TAG = "ReportFragment";

	@BindView(R.id.toolbar)
	Toolbar toolbar;
	@BindView(R.id.report_im_in_danger)
	Button  buttonReport;
	@BindView(R.id.report_collapse)
	Button  buttonCollapse;
	@BindView(R.id.report_block)
	Button  buttonBlock;
	private Unbinder unbinder;

	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iAlertListView = new MvpView<>(this::onError, this);


	private OnAlertListInteractionListener mListener;

	public ReportFragment() {
		// Required empty public constructor
	}


	public static ReportFragment newInstance() {
		ReportFragment fragment = new ReportFragment();
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
					context.toString() + " must implement OnAlertListInteractionListener");
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
		return R.string.fragment_title_report;
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
		View view = inflater.inflate(R.layout.fragment_report, container, false);
		unbinder = ButterKnife.bind(this, view);
		return view;
	}

	@Override
	public void onResume() {
		super.onResume();
		if (alertListPresenter() != null) alertListPresenter().addView(iAlertListView);
	}

	@Override
	public void onPause() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iAlertListView);

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
