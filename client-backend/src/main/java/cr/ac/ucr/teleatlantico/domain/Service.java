package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;

public class Service {

	private int serviceId;
	
	private String name;
	
	private String createBy;
	
	private Date createAt;
	
	private String modifyBy;
	
	private Date modifyAt;
	

	
	public Service(int serviceId, String name, String createBy, Date createAt, String modifyBy, Date modifyAt) {
		this.serviceId = serviceId;
		this.name = name;
		this.createBy = createBy;
		this.createAt = createAt;
		this.modifyBy = modifyBy;
		this.modifyAt = modifyAt;
	}

	public Service() {
		this.serviceId = 0;
		this.name = "";
		this.createBy = "";
		this.createAt = new Date();
		this.modifyBy = "";
		this.modifyAt = new Date();
	}

	public int getServiceId() {
		return serviceId;
	}

	public void setServiceId(int serviceId) {
		this.serviceId = serviceId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getCreateBy() {
		return createBy;
	}

	public void setCreateBy(String createBy) {
		this.createBy = createBy;
	}

	public Date getCreateAt() {
		return createAt;
	}

	public void setCreateAt(Date createAt) {
		this.createAt = createAt;
	}

	public String getModifyBy() {
		return modifyBy;
	}

	public void setModifyBy(String modifyBy) {
		this.modifyBy = modifyBy;
	}

	public Date getModifyAt() {
		return modifyAt;
	}

	public void setModifyAt(Date modifyAt) {
		this.modifyAt = modifyAt;
	}
	
}
