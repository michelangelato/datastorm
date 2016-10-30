package com.datastorm.hackreativityandroid.adapters;

import android.view.ViewGroup;

import com.dadino.quickstart.core.adapters.BaseListAdapter;
import com.datastorm.hackreativityandroid.adapters.holders.ImageHolder;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertImage;


public class ImageAdapter extends BaseListAdapter<AlertImage, ImageHolder> {

	@Override
	public long getItemIdSafe(int position) {
		return getItem(position).getId();
	}

	@Override
	protected ImageHolder getHolder(ViewGroup parent, int viewType) {
		return new ImageHolder(
				inflater(parent.getContext()).inflate(ImageHolder.layout(), parent, false));
	}
}
