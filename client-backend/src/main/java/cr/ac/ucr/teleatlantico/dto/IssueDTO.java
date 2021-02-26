package cr.ac.ucr.teleatlantico.dto;

import java.util.Date;

public class IssueDTO{

	private int reportNumber;
	private String resolutionComment;
	private	String status;
	private	String classification;
	private int serviceId;
	private Date reportDate;
	private int createBy;
	private Date createAt;
	private Date modifyAt;
	
	public IssueDTO(int reportNumber, String resolutionComment, String status, String classification, int serviceId,
			Date reportDate, int createBy, Date createAt, Date modifyAt) {
		this.reportNumber = reportNumber;
		this.resolutionComment = resolutionComment;
		this.status = status;
		this.classification = classification;
		this.serviceId = serviceId;
		this.reportDate = reportDate;
		this.createBy = createBy;
		this.createAt = createAt;
		this.modifyAt = modifyAt;
	}
	
	public IssueDTO() {

	}

	public int getReportNumber() {
		return reportNumber;
	}

	public void setReportNumber(int reportNumber) {
		this.reportNumber = reportNumber;
	}

	public String getResolutionComment() {
		return resolutionComment;
	}

	public void setResolutionComment(String resolutionComment) {
		this.resolutionComment = resolutionComment;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getClassification() {
		return classification;
	}

	public void setClassification(String classification) {
		this.classification = classification;
	}

	public int getServiceId() {
		return serviceId;
	}

	public void setServiceId(int serviceId) {
		this.serviceId = serviceId;
	}

	public Date getReportDate() {
		return reportDate;
	}

	public void setReportDate(Date reportDate) {
		this.reportDate = reportDate;
	}

	public int getCreateBy() {
		return createBy;
	}

	public void setCreateBy(int createBy) {
		this.createBy = createBy;
	}

	public Date getCreateAt() {
		return createAt;
	}

	public void setCreateAt(Date createAt) {
		this.createAt = createAt;
	}

	public Date getModifyAt() {
		return modifyAt;
	}

	public void setModifyAt(Date modifyAt) {
		this.modifyAt = modifyAt;
	}
	
	
}
