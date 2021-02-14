package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;

public class Client {

	private int clientId;
	
	private String name;
	
	private String firstSurname;
	
	private String secondSurname;
	
	private String address;
	
	private String phone;
	
	private String secondContact;
	
	private String email;
	
	private String password;
	
	private String createBy;
	
	private Date createAt;
	
	private String modifyBy;
	
	private Date modifyAt;
	
	
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
