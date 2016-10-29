package com.datastorm.hackreativityandroid.adapters.holders.alerts;

import android.view.View;

import com.datastorm.hackreativityandroid.R;
import com.datastorm.hackreativityandroid.mvp.entitites.Alert;
import com.datastorm.hackreativityandroid.mvp.entitites.AlertImage;
import com.datastorm.hackreativityandroid.widgets.AspectRatioImageView;
import com.squareup.picasso.Picasso;

import butterknife.BindView;


public class Alert1ImageHolder extends AlertTextOnlyHolder {

	@BindView(R.id.alert_image_1)
	AspectRatioImageView image;

	public Alert1ImageHolder(View itemView, boolean withClickListener) {
		super(itemView, withClickListener);
	}

	@Override
	public void bindItem(Alert item, int position) {
		super.bindItem(item, position);
		AlertImage im = item.getImages()
		                    .get(0);
		image.setAspectRatio(im.getWidth() / im.getHeight());
		image.setAspectRatioEnabled(true);
		Picasso.with(image.getContext())
		       .load(im.getUrl())
		       .into(image);
	}
}
