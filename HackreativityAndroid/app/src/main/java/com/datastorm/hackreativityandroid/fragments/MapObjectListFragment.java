package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.dadino.quickstart.core.fragments.DrawerToggleFragment;
import com.dadino.quickstart.core.mvp.components.ErrorHandler;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnMapObjectListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.MapObject;
import com.datastorm.hackreativityandroid.mvp.usecases.mapobjectlist.MapObjectListMVP;
import com.datastorm.hackreativityandroid.utils.MapDrawer;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class MapObjectListFragment extends DrawerToggleFragment implements OnMapReadyCallback {

	public static final String TAG = "MapFragment";

	@BindView(R.id.toolbar)
	Toolbar     toolbar;
	@BindView(R.id.map)
	MapFragment mapFragment;

	private Unbinder unbinder;

	private PresenterManager<MapObjectListMVP.Presenter> mapObjectListPresenterManager;
	private OnMapObjectListInteractionListener           mListener;
	private GoogleMap                                    googleMap;
	private MvpView<List<MapObject>> iMapObjectListView = new MvpView<>(this::onObjectsLoaded,
			this::onError, this);

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
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		initPresenters();
	}

	private void initPresenters() {
		mapObjectListPresenterManager = new PresenterManager<>(this, new MapObjectListMVP
				.Factory(), null).bindTo(this);
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
		if (mapObjectListPresenter() != null) mapObjectListPresenter().addView(iMapObjectListView);
	}

	@Override
	public void onPause() {
		if (mapObjectListPresenter() != null) mapObjectListPresenter().removeView(
				iMapObjectListView);

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
		mapFragment.getMapAsync(this);
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
	public Toolbar toolbar() {
		return toolbar;
	}

	@Override
	public int title() {
		return R.string.fragment_title_map;
	}

	private void onObjectsLoaded(List<MapObject> objects) {
		if (googleMap != null) MapDrawer.setupMap(getContext(), googleMap, objects);
	}

	private void onError(Throwable error) {
		//TODO
		ErrorHandler.analyzeError(error);
	}

	private MapObjectListMVP.Presenter mapObjectListPresenter() {
		return mapObjectListPresenterManager != null ? mapObjectListPresenterManager.get() : null;
	}

	@Override
	public void onMapReady(GoogleMap googleMap) {
		this.googleMap = googleMap;
		if (mapObjectListPresenter() != null) mapObjectListPresenter().load();
	}
}
