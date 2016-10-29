package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.Date;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "topic")
public class AbstractTopic {

	@Expose
	@SerializedName("Topic")
	@Column(name = "topic")
	@Key
	String topic;

	@Expose
	@SerializedName("UltimaSottoscrizione")
	@Column(name = "last_subscribed_to")
	Date lastSubscribedTo;

	@Expose
	@SerializedName("nelat")
	@Column(name = "ne_lat")
	double neLat;

	@Expose
	@SerializedName("nelon")
	@Column(name = "ne_lon")
	double neLon;

	@Expose
	@SerializedName("solat")
	@Column(name = "so_lat")
	double soLat;

	@Expose
	@SerializedName("solon")
	@Column(name = "so_lon")
	double soLon;

	@Expose
	@SerializedName("Pinnato")
	@Column(name = "pinned")
	boolean pinned;
}
