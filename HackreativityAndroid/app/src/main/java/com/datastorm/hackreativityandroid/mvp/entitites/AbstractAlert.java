package com.datastorm.hackreativityandroid.mvp.entitites;


import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

import io.requery.CascadeAction;
import io.requery.Column;
import io.requery.Entity;
import io.requery.Key;
import io.requery.OneToMany;
import io.requery.Table;

@Entity(stateless = true)
@Table(name = "alert")
public class AbstractAlert {

	@Expose
	@SerializedName("Id")
	@Column(name = "id")
	@Key
	long id;

	@Expose
	@SerializedName("Topic")
	@Column(name = "topic")
	String topic;

	@Expose
	@SerializedName("Titolo")
	@Column(name = "title")
	String title;

	@Expose
	@SerializedName("Descrizione")
	@Column(name = "description")
	String description;

	@Expose
	@SerializedName("Immagini")
	@Column(name = "images")
	@OneToMany(cascade = {CascadeAction.DELETE, CascadeAction.SAVE})
	List<AlertImage> images;

	@Expose
	@SerializedName("Links")
	@Column(name = "links")
	@OneToMany(cascade = {CascadeAction.DELETE, CascadeAction.SAVE})
	List<AlertLink> links;

	@Expose
	@SerializedName("Mappe")
	@Column(name = "maps")
	@OneToMany(cascade = {CascadeAction.DELETE, CascadeAction.SAVE})
	List<AlertMap> maps;
}
