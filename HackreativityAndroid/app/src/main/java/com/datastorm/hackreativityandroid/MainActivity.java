package com.datastorm.hackreativityandroid;

import android.os.Bundle;
import android.support.v7.widget.Toolbar;

import com.dadino.quickstart.core.BaseActivity;
import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.usecases.alertlist.AlertListMVP;
import com.datastorm.hackreativityandroid.widgets.PresentedAlertListView;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;

public class MainActivity extends BaseActivity {

	@BindView(R.id.alert_list)
	PresentedAlertListView alertList;
	@BindView(R.id.toolbar)
	Toolbar                toolbar;
	private PresenterManager<AlertListMVP.Presenter> alertListPresenterManager;
	private MvpView<List<Alert>> iAlertListView = new MvpView<>(this::onError, this);

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		ButterKnife.bind(this);
		setSupportActionBar(toolbar);
		initPresenters();
	}

	private void initPresenters() {
		alertListPresenterManager = new PresenterManager<>(this, new AlertListMVP.Factory(),
				IPresenter::load).bindTo(this);
	}

	@Override
	protected void onStart() {
		super.onStart();
		if (alertListPresenter() != null) alertListPresenter().addView(iAlertListView);
		if (alertList != null) alertList.setPresenter(alertListPresenter());
	}

	@Override
	protected void onStop() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iAlertListView);
		if (alertList != null) alertList.setPresenter(null);

		super.onStop();
	}

	private void onError(Throwable error) {
		//TODO
	}

	private AlertListMVP.Presenter alertListPresenter() {
		return alertListPresenterManager != null ? alertListPresenterManager.get() : null;
	}
}
