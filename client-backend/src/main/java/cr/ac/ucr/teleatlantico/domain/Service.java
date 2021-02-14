package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Service")
public class Service {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ServiceId")
	private int serviceId;
	
	@Column(name = "Name", unique = false, length = 25)
	private String name;
	
	@Column(name = "CreateBy", unique = false, length = 25)
	private String createBy;
	
	@Column(name = "CreateAt", unique = false)
	private Date createAt;
	
	@Column(name = "ModifyBy", unique = false, length = 25)
	private String modifyBy;
	
	@Column(name = "ModifyAt", unique = false)
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
