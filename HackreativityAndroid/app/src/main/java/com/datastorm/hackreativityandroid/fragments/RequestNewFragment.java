package com.datastorm.hackreativityandroid.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Spinner;

import com.dadino.quickstart.core.fragments.DrawerToggleFragment;
import com.dadino.quickstart.core.mvp.components.presenter.MvpView;
import com.dadino.quickstart.core.mvp.components.presenter.PresenterManager;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnRequestNewInteractionListener;
import com.datastorm.hackreativityandroid.mvp.entitites.Request;
import com.datastorm.hackreativityandroid.mvp.usecases.requestnew.RequestNewMVP;

import java.util.Date;

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
	public  int      selectedType;

	private PresenterManager<RequestNewMVP.Presenter> requestNewPresenterManager;
	private MvpView<Boolean> iRequestNewView = new MvpView<>(this::onRequestSaved, this::onError,
			this);


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
	public Toolbar toolbar() {
		return toolbar;
	}

	@Override
	public int title() {
		return R.string.fragment_title_request_new;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		initPresenters();
	}

	private void initPresenters() {
		requestNewPresenterManager = new PresenterManager<>(this, new RequestNewMVP.Factory(),
				null).bindTo(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
	                         Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_request_new, container, false);
		unbinder = ButterKnife.bind(this, view);
		send.setOnClickListener(view1 -> onSendClicked());
		type.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
			@Override
			public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
				selectedType = i;
			}

			@Override
			public void onNothingSelected(AdapterView<?> adapterView) {
				selectedType = 0;
			}
		});
		return view;
	}

	private void onSendClicked() {
		Request request = new Request();
		request.setRequestedAt(new Date());
		request.setAddress(address.getText()
		                          .toString()
		                          .trim());
		request.setType(selectedType);
		request.setConditionDoor(door.isChecked());
		request.setConditionStairs(stairs.isChecked());
		if (alertListPresenter() != null) alertListPresenter().onSendClicked(request);
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

	private void onSendClicked() {
		Request request = new Request();
		request.setRequestedAt(new Date());
		request.setAddress(address.getText()
		                          .toString()
		                          .trim());
		request.setType(selectedType);
		request.setConditionDoor(door.isChecked());
		request.setConditionStairs(stairs.isChecked());
		if (alertListPresenter() != null) alertListPresenter().onSendClicked(request);
	}

	@Override
	public void onDestroyView() {
		unbinder.unbind();
		super.onDestroyView();
	}

	private void onRequestSaved(boolean saved) {
		getActivity().finish();
	}

	private void onError(Throwable error) {
		//TODO
		error.printStackTrace();
	}

	private RequestNewMVP.Presenter alertListPresenter() {
		return requestNewPresenterManager != null ? requestNewPresenterManager.get() : null;
	}
}
