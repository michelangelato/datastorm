package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.dadino.quickstart.core.interfaces.IPresenter;
import com.dadino.quickstart.core.mvp.components.ErrorHandler;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.adapters.TopicAlertPagerAdapter;
import com.datastorm.hackreativityandroid.interfaces.OnTopicListInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;
import com.datastorm.hackreativityandroid.mvp.usecases.topiclist.TopicListMVP;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class TopicListFragment extends DrawerToggleFragment {

	public static final String TAG = "TopicListFragment";

	@BindView(R.id.toolbar)
	Toolbar   toolbar;
	@BindView(R.id.topic_pager)
	ViewPager pager;
	@BindView(R.id.topic_tabs)
	TabLayout tabs;
	private Unbinder unbinder;

	private PresenterManager<TopicListMVP.Presenter> topicListPresenterManager;
	private OnTopicListInteractionListener           mListener;
	private TopicAlertPagerAdapter                   mAdapter;
	private MvpView<List<Topic>> iTopicListView = new MvpView<>(this::onTopicsLoaded,
			this::onError,
			this);

	public TopicListFragment() {
		// Required empty public constructor
	}

	public static TopicListFragment newInstance() {
		TopicListFragment fragment = new TopicListFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		mAdapter = new TopicAlertPagerAdapter(getFragmentManager());
		initPresenters();
	}

	private void initPresenters() {
		topicListPresenterManager = new PresenterManager<>(this, new TopicListMVP.Factory(),
				IPresenter::load).bindTo(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_topic_list, container, false);
		unbinder = ButterKnife.bind(this, view);
		return view;
	}

	@Override
	public void onResume() {
		super.onResume();
		if (alertListPresenter() != null) alertListPresenter().addView(iTopicListView);
	}

	@Override
	public void onPause() {
		if (alertListPresenter() != null) alertListPresenter().removeView(iTopicListView);
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
		pager.setAdapter(mAdapter);
		tabs.setupWithViewPager(pager);
	}

	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnTopicListInteractionListener) {
			mListener = (OnTopicListInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnTopicListInteractionListener");
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
		return R.string.fragment_title_alert_list;
	}

	private void onTopicsLoaded(List<Topic> topics) {
		mAdapter.setTopics(topics);
	}

	private void onError(Throwable error) {
		//TODO
		ErrorHandler.analyzeError(error);
	}

	private TopicListMVP.Presenter alertListPresenter() {
		return topicListPresenterManager != null ? topicListPresenterManager.get() : null;
	}
}
