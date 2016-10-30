package com.datastorm.hackreativityandroid.widgets;

import android.content.Context;
import android.support.design.widget.FloatingActionButton;
import android.util.AttributeSet;


public class HideableFab extends FloatingActionButton {

	private boolean mCanShow = true;

	public HideableFab(Context context) {
		super(context);
	}

	public HideableFab(Context context, AttributeSet attrs) {
		super(context, attrs);
	}

	public HideableFab(Context context, AttributeSet attrs, int defStyleAttr) {
		super(context, attrs, defStyleAttr);
	}

	public void setCanShow(boolean canShow) {
		this.mCanShow = canShow;
		if (!mCanShow) hide();
		else show();
	}

	@Override
	public void show() {
		if (mCanShow) super.show();
	}
}
