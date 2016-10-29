package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.ManyToOne;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "alert_image")
public class AbstractAlertImage {

	@Expose
	@SerializedName("Id")
	@Column(name = "id")
	@Key
	long id;

	@Expose
	@SerializedName("Url")
	@Column(name = "url")
	String url;

	@ManyToOne
	@Column(name = "alert")
	@Key
	Alert alert;
}
