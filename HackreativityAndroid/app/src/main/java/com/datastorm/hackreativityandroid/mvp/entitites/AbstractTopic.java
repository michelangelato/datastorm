package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.Date;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "alert")
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
}
