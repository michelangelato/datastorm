package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.Date;

import io.requery.Column;
import io.requery.Entity;
import io.requery.Generated;
import io.requery.Key;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "report")
public class AbstractReport {

	@Expose
	@SerializedName("Id")
	@Column(name = "id")
	@Key
	@Generated
	long id;

	@Expose
	@SerializedName("Tipo")
	@Column(name = "type")
	int type;

	@Expose
	@SerializedName("DataSegnalazione")
	@Column(name = "reported_at")
	Date reportedAt;

	@Column(name = "synced")
	Boolean synced;
}
