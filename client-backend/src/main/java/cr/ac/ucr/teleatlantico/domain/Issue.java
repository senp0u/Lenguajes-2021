package cr.ac.ucr.teleatlantico.domain;

import java.util.Date;
import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;


@Entity
@Table(name = "Issue")
public class Issue {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "IssueId")
	private int issueId;
	
	@Column(name = "Description", unique = false, nullable = false ,length = 100)
	private String description;
	
	@Column(name = "Status", unique = false, nullable = false ,length = 15)
	private String status;
	
	@Column(name = "SupporterUser", unique = false, length = 25)
	private String supporterUser;
	
	@Column(name = "CreateBy", unique = false, nullable = false ,length = 25)
	private String createBy;
	
	@Column(name = "CreateAt", nullable = false ,unique = false)
	private Date createAt;
	
	@Column(name = "ModifyBy", unique = false, length = 25)
	private String modifyBy;
	
	@Column(name = "ModifyAt", unique = false)
	private Date modifyAt;
	
	@ManyToOne(targetEntity = Service.class,fetch = FetchType.EAGER,
			   cascade = CascadeType.ALL, optional=false)
	@JoinColumn(name = "ServiceId", referencedColumnName = "ServiceId",nullable = false)
	private Service service;
	
	@OneToMany(targetEntity = Comment.class,fetch = FetchType.LAZY,
			   cascade = CascadeType.ALL)
	@JoinColumn(name = "IssueId", referencedColumnName = "IssueId", nullable = false)
	private Set<Comment> comments = new HashSet<Comment>();

	public Issue(int issueId, String description, String status, String supporterUser, String createBy, Date createAt,
			String modifyBy, Date modifyAt, Service service, Set<Comment> comments) {
		this.issueId = issueId;
		this.description = description;
		this.status = status;
		this.supporterUser = supporterUser;
		this.createBy = createBy;
		this.createAt = createAt;
		this.modifyBy = modifyBy;
		this.modifyAt = modifyAt;
		this.service = service;
		this.comments = comments;
	}
	
	public Issue() {
		this.issueId = 0;
		this.description = "";
		this.status = "";
		this.supporterUser = "";
		this.createBy = "";
		this.createAt = new Date();
		this.modifyBy = "";
		this.modifyAt = new Date();
		this.service = new Service();
	}

	public int getIssueId() {
		return issueId;
	}

	public void setIssueId(int issueId) {
		this.issueId = issueId;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getSupporterUser() {
		return supporterUser;
	}

	public void setSupporterUser(String supporterUser) {
		this.supporterUser = supporterUser;
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

	public Service getService() {
		return service;
	}

	public void setService(Service service) {
		this.service = service;
	}

	public Set<Comment> getComments() {
		return comments;
	}

	public void setComments(Set<Comment> comments) {
		this.comments = comments;
	}
	
}
