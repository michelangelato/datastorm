package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.dadino.quickstart.core.fragments.BaseFragment;
import com.dadino.quickstart.core.mvp.components.ErrorHandler;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnTopicAddInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Topic;
import com.datastorm.hackreativityandroid.mvp.usecases.topicadd.TopicAddMVP;
import com.datastorm.hackreativityandroid.mvp.usecases.topicsearch.TopicSearchListMVP;
import com.datastorm.hackreativityandroid.widgets.PresentedTopicListView;
import com.jakewharton.rxbinding.widget.RxTextView;

import java.util.List;
import java.util.concurrent.TimeUnit;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;

public class AddTopicFragment extends BaseFragment {

	public static final String TAG = "AddTopicFragment";

	@BindView(R.id.topic_add_list)
	PresentedTopicListView topicList;
	@BindView(R.id.topic_add_search_box)
	EditText               searchBox;
	private Unbinder unbinder;

	private PresenterManager<TopicAddMVP.Presenter> topicAddPresenterManager;
	private MvpView<Boolean>     iTopicAddView    = new MvpView<>(this::onError, this);
	private MvpView<List<Topic>> iTopicSearchView = new MvpView<>(this::onError, this);


	private OnTopicAddInteractionListener                  mListener;
	private PresenterManager<TopicSearchListMVP.Presenter> topicSearchPresenterManager;

	public AddTopicFragment() {
		// Required empty public constructor
	}

	public static AddTopicFragment newInstance() {
		AddTopicFragment fragment = new AddTopicFragment();
		Bundle args = new Bundle();
		fragment.setArguments(args);
		return fragment;
	}

	@Override
	public void onAttach(Context context) {
		super.onAttach(context);
		if (context instanceof OnTopicAddInteractionListener) {
			mListener = (OnTopicAddInteractionListener) context;
		} else {
			throw new RuntimeException(
					context.toString() + " must implement OnTopicAddInteractionListener");
		}
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_topic_add, container, false);
		unbinder = ButterKnife.bind(this, view);
		return view;
	}

	@Override
	public void onResume() {
		super.onResume();
		if (topicAddPresenter() != null) topicAddPresenter().addView(iTopicAddView);
		if (topicSearchPresenter() != null) topicSearchPresenter().addView(iTopicSearchView);
		if (topicList != null) topicList.setPresenter(topicSearchPresenter());
	}

	@Override
	public void onPause() {
		if (topicAddPresenter() != null) topicAddPresenter().removeView(iTopicAddView);
		if (topicSearchPresenter() != null) topicSearchPresenter().removeView(iTopicSearchView);
		if (topicList != null) topicList.setPresenter(null);

		super.onPause();
	}

	@Override
	public void onDestroyView() {
		unbinder.unbind();
		super.onDestroyView();
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	private void onTopicSelected(Topic topic) {
		if (topicAddPresenter() != null) topicAddPresenter().onAddClicked(topic.toString());
	}

	private void performSerch(CharSequence filter) {
		if (topicSearchPresenter() != null) topicSearchPresenter().onFilterChanged(
				filter.toString());
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		initPresenters();
	}

	@Override
	public void onViewCreated(View view, Bundle savedInstanceState) {
		super.onViewCreated(view, savedInstanceState);
		topicList.setOnTopicClickedListener((v, topic) -> onTopicSelected(topic));
		addSubscription(RxTextView.textChanges(searchBox)
		                          .filter(text -> text.length() >= 2)
		                          .debounce(300, TimeUnit.MILLISECONDS)
		                          .subscribe(this::performSerch, ErrorHandler::analyzeError));
	}

	private void initPresenters() {
		topicAddPresenterManager = new PresenterManager<>(this, new TopicAddMVP.Factory(),
				null).bindTo(this);
		topicSearchPresenterManager = new PresenterManager<>(this, new TopicSearchListMVP
				.Factory(),
				null).bindTo(this);
	}

	private void onError(Throwable error) {
		//TODO
		ErrorHandler.analyzeError(error);
	}

	private TopicAddMVP.Presenter topicAddPresenter() {
		return topicAddPresenterManager != null ? topicAddPresenterManager.get() : null;
	}

	private TopicSearchListMVP.Presenter topicSearchPresenter() {
		return topicSearchPresenterManager != null ? topicSearchPresenterManager.get() : null;
	}
}
