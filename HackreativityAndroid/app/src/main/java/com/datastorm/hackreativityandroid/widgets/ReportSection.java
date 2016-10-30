package com.datastorm.hackreativityandroid.widgets;

import android.content.Context;
import android.support.annotation.StringRes;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.dadino.quickstart.core.utils.Logs;
import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.interfaces.OnReportOptionClickedListener;
import com.datastorm.hackreativityandroid.mvp.entitites.ReportOption;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;

public class ReportSection extends LinearLayout {

	@BindView(R.id.report_section_header)
	TextView     title;
	@BindView(R.id.report_section_entries)
	LinearLayout entries;
	private OnReportOptionClickedListener listener;

	public ReportSection(Context context) {
		super(context);
		init();
	}

	public ReportSection(Context context, AttributeSet attrs) {
		super(context, attrs);
		init();
	}

	public ReportSection(Context context, AttributeSet attrs, int defStyleAttr) {
		super(context, attrs, defStyleAttr);
		init();
	}

	private void init() {
		setOrientation(VERTICAL);
		inflate(getContext(), R.layout.view_report_section, this);
		ButterKnife.bind(this);
		title.setOnClickListener(view -> onTitleClicked());
	}

	private void onTitleClicked() {
		Logs.ui("ReportSection header clicked");
		if (entries.getVisibility() == VISIBLE) entries.setVisibility(GONE);
		else entries.setVisibility(VISIBLE);
	}

	public void setTitle(@StringRes int stringRes) {
		setTitle(getResources().getString(stringRes));
	}

	public void setTitle(String string) {
		title.setText(string);
	}

	public void setEntries(List<ReportOption> options) {
		entries.removeAllViews();
		for (ReportOption option : options) {
			addOption(option);
		}
	}

	public void setOnReportOptionClickedListener(OnReportOptionClickedListener listener) {
		this.listener = listener;
	}

	private void addOption(ReportOption option) {
		TextView entry = (TextView) LayoutInflater.from(getContext())
		                                          .inflate(R.layout.view_report_option, entries,
				                                          false);
		entry.setText(option.getDescription());
		int _16dp = getResources().getDimensionPixelSize(R.dimen.dimen_16dp);
		entry.setPadding(_16dp, _16dp, _16dp, _16dp);
		LinearLayout.LayoutParams params = new LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,
				LinearLayout.LayoutParams.WRAP_CONTENT);
		entry.setLayoutParams(params);
		entry.setOnClickListener(view -> onOptionClicked(option));
		entries.addView(entry);
	}

	private void onOptionClicked(ReportOption option) {
		if (listener != null) listener.onReportOptionClicked(option);
	}
}
