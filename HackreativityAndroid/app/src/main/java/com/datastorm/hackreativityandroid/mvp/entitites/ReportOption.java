package com.datastorm.hackreativityandroid.mvp.entitites;

public class ReportOption {

	private String description;
	private long   id;

	public ReportOption(long id, String description) {
		this.id = id;
		this.description = description;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}
}
