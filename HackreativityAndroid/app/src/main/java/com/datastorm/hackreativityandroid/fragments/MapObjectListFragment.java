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
import com.datastorm.hackreativityandroid.interfaces.OnMapObjectListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.usecases.mapobjectlist.MapObjectListMVP;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class MapObjectListFragment extends DrawerToggleFragment {

	public static final String TAG = "MapFragment";

	@BindView(R.id.toolbar)
	Toolbar toolbar;

	private Unbinder unbinder;

	private PresenterManager<MapObjectListMVP.Presenter> mapObjectListPresenterManager;
	private MvpView<List<MapObject>> iAlertListView = new MvpView<>(this::onError, this);

	private OnMapObjectListInteractionListener mListener;

	public MapObjectListFragment() {
		// Required empty public constructor
	}

	public static MapObjectListFragment newInstance() {
		MapObjectListFragment fragment = new MapObjectListFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}

	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnMapObjectListInteractionListener) {
			mListener = (OnMapObjectListInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnMapObjectListInteractionListener");
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
		return R.string.fragment_title_map;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		initPresenters();
	}

	private void initPresenters() {
		mapObjectListPresenterManager = new PresenterManager<>(this, new MapObjectListMVP
				.Factory(),
				IPresenter::load).bindTo(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_map, container, false);
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


	private void onError(Throwable error) {
		//TODO
	}

	private MapObjectListMVP.Presenter alertListPresenter() {
		return mapObjectListPresenterManager != null ? mapObjectListPresenterManager.get() : null;
	}
}
