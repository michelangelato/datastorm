package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.dadino.quickstart.core.fragments.DrawerToggleFragment;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnAlertClickedListener;
import com.datastorm.hackreativityandroid.interfaces.OnAlertListInteractionListener;
import com.datastorm.hackreativityandroid.interfaces.OnReportOptionClickedListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.ReportOption;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;
import com.datastorm.hackreativityandroid.widgets.ReportSection;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class ReportFragment extends DrawerToggleFragment implements OnAlertClickedListener,
		OnReportOptionClickedListener {

	public static final String TAG = "ReportFragment";

	@BindView(R.id.toolbar)
	Toolbar       toolbar;
	@BindView(R.id.report_im_in_danger)
	ReportSection danger;
	@BindView(R.id.report_collapse)
	ReportSection collapse;
	@BindView(R.id.report_block)
	ReportSection block;
	private Unbinder unbinder;

	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iReportView = new MvpView<>(this::onError, this);


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
		if (alertListPresenter() != null) alertListPresenter().addView(iReportView);
	}

	@Override
	public void onPause() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iReportView);

		super.onPause();
	}

	@Override
	public void onDestroyView() {
		unbinder.unbind();
		super.onDestroyView();
	}

	@Override
	public void onViewCreated(View view, Bundle savedInstanceState) {
		super.onViewCreated(view, savedInstanceState);
		danger.setTitle(R.string.report_danger);
		collapse.setTitle(R.string.report_collapse);
		block.setTitle(R.string.report_block);

		List<ReportOption> dangerOptions = new ArrayList<>();
		dangerOptions.add(new ReportOption(1, "...sotto le macerie"));
		dangerOptions.add(new ReportOption(2, "...emergenza medica"));
		dangerOptions.add(new ReportOption(3, "...senza una rifugio"));

		List<ReportOption> collapseOptions = new ArrayList<>();
		collapseOptions.add(new ReportOption(1, "...la mia abitazione"));
		collapseOptions.add(new ReportOption(2, "...un edificio vicino a me"));
		collapseOptions.add(new ReportOption(3, "...una montagna"));

		List<ReportOption> blockOptions = new ArrayList<>();
		blockOptions.add(new ReportOption(1, "...una strada"));
		blockOptions.add(new ReportOption(2, "...un ponte/galleria"));
		blockOptions.add(new ReportOption(3, "...la mia via di fuga"));

		danger.setEntries(dangerOptions);
		collapse.setEntries(collapseOptions);
		block.setEntries(blockOptions);

		danger.setOnReportOptionClickedListener(this);
		collapse.setOnReportOptionClickedListener(this);
		block.setOnReportOptionClickedListener(this);
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
	public Toolbar toolbar() {
		return toolbar;
	}

	@Override
	public int title() {
		return R.string.fragment_title_report;
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

	@Override
	public void onReportOptionClicked(ReportOption reportOption) {
		Log.d("UI", "Option clicked");
		Toast.makeText(getContext(), R.string.report_sent, Toast.LENGTH_SHORT)
		     .show();
	}
}
